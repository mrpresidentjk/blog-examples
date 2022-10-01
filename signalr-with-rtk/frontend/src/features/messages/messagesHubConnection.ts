import {HubConnectionBuilder, HubConnectionState} from "@microsoft/signalr";
import {API_BASE_URL} from "../../app/config";

export const messagesHubConnection = new HubConnectionBuilder()
    .withUrl(`${API_BASE_URL}/messageHub`)
    .build();

export const isDisconnected = () =>
    messagesHubConnection.state === HubConnectionState.Disconnected;
