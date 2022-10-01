import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { Message } from "./types";
import { API_BASE_URL } from "../../app/config";

import {
  createEntityAdapter,
  createSelector,
  EntityState,
} from "@reduxjs/toolkit";
import { RootState } from "../../app/store";
import {messagesHubConnection} from "./messagesHubConnection";

export const messagesAdapter = createEntityAdapter<Message>({
  selectId: (message) => message.uuid,
});

const initialState = messagesAdapter.getInitialState();

// Define a service using a base URL and expected endpoints
export const messagesApi = createApi({
  reducerPath: "messagesApi",
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
  endpoints: (builder) => {
    return {
      getMessages: builder.query<EntityState<Message>, void>({
        query: () => "Messages",
        transformResponse(response: Message[]) {
          return messagesAdapter.addMany(initialState, response);
        },
        async onCacheEntryAdded(
            arg,
            { updateCachedData, cacheDataLoaded, cacheEntryRemoved, dispatch }
        ) {
          try {
            await cacheDataLoaded
            messagesHubConnection.on("MessageCreated", (message: Message) => {
              updateCachedData(draft => messagesAdapter.upsertOne(draft, message));
            })
          } catch {}
          await cacheEntryRemoved
        }
      }),
    };
  },
});

const selectMessagesResult = messagesApi.endpoints.getMessages.select();

const selectMessagesData = createSelector(
  selectMessagesResult,
  (messageResult) => messageResult.data
);

export const selectMessageEntityState = createSelector(
  selectMessagesData,
  (messageData) => messageData || initialState
);

// Export hooks for usage in function components, which are
// auto-generated based on the defined endpoints
export const { useGetMessagesQuery } = messagesApi;

export const { selectAll: selectAllMessages } =
  messagesAdapter.getSelectors<RootState>(selectMessageEntityState);

export default messagesApi;
