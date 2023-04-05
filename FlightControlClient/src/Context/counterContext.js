import { createContext, useState } from "react";

export const counterContext = createContext({});

const Provider = counterContext.Provider;

export const CounterProvider = ({ children }) => {
    const [count, setCount] = useState(10);
    const handleAdd = () => {
        setCount(count + 1);
    }

    const value = {
        count,
        handleAdd
    }

    return (
        <Provider value={value}>
            {children}
        </Provider>
    )
}