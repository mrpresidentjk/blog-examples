import {
  createListenerMiddleware,
  TypedStartListening,
} from "@reduxjs/toolkit";
import { AppDispatch, RootState } from "../../app/store";
import {isDisconnected, messagesHubConnection} from "./messagesHubConnection";

const listenerMiddleware = createListenerMiddleware();

export type AppStartListening = TypedStartListening<RootState, AppDispatch>;

const startListening = listenerMiddleware.startListening as AppStartListening;

startListening({
  predicate: isDisconnected,
  effect: async (action, listenerApi) => {
    await messagesHubConnection.start();
    await listenerApi.take(isDisconnected);
  },
});

export default listenerMiddleware.middleware;
