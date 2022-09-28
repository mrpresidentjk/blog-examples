import { HubConnectionBuilder, HubConnectionState } from "@microsoft/signalr";
import {
  createListenerMiddleware,
  TypedStartListening,
} from "@reduxjs/toolkit";
import { AppDispatch, RootState } from "../../app/store";
import { Message } from "./types";
import { messagesAdapter, messagesApi } from "./messagesApi";
import { API_BASE_URL } from "../../app/config";

export const hubConnection = new HubConnectionBuilder()
  .withUrl(`${API_BASE_URL}/messageHub`)
  .build();

const listenerMiddleware = createListenerMiddleware();

export type AppStartListening = TypedStartListening<RootState, AppDispatch>;

const startListening = listenerMiddleware.startListening as AppStartListening;

const isDisconnected = () =>
  hubConnection.state === HubConnectionState.Disconnected;

startListening({
  predicate: isDisconnected,
  effect: async (action, listenerApi) => {
    hubConnection.on("MessageCreated", (message: Message) => {
      listenerApi.dispatch(
        messagesApi.util.updateQueryData("getMessages", undefined, (draft) => {
          messagesAdapter.upsertOne(draft, message);
        })
      );
    });
    await hubConnection.start();
    await listenerApi.take(isDisconnected);
  },
});

export default listenerMiddleware.middleware;
