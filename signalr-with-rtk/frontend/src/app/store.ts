import { configureStore } from "@reduxjs/toolkit";
import messagesApi from "../features/messages/messagesApi";
import messagesMiddleware from "../features/messages/messagesMiddleware";

export const store = configureStore({
  reducer: {
    [messagesApi.reducerPath]: messagesApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(messagesMiddleware, messagesApi.middleware),
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
