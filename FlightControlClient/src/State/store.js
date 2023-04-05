import { configureStore } from "@reduxjs/toolkit";

import counterReducer from './counter';
import colorSwitchReducer from './colorSwitch';
import todosReducer from "./todos";

import { Provider } from "react-redux";

const store = configureStore({
    reducer: {
        counter: counterReducer,
        colorSwitch: colorSwitchReducer,
        todos: todosReducer
    }
})

export const ReduxProvider = ({ children }) => {
    return (
        <Provider store={store}>
            {children}
        </Provider>
    )
}