import React from "react";
import {
  selectAllMessages,
  useGetMessagesQuery,
} from "./features/messages/messagesApi";
import { useAppSelector } from "./app/hooks";

const App = () => {
  useGetMessagesQuery();

  const messages = useAppSelector(selectAllMessages);

  return (
    <div className="App">
      <ol>
        {messages.map((message) => (
          <div key={message.uuid}>
            UUID: {message.uuid} Content: {message.content}
          </div>
        ))}
      </ol>
    </div>
  );
};

export default App;
