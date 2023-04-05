import { createContext, useState } from "react";

export const themeContext = createContext({});

const { Provider } = themeContext;

export const ThemeProvider = ({ children }) => {
    const [selected, setSelected] = useState('light');

    const list = [
        { id: 'dark', name: 'Dark' },
        { id: 'light', name: 'Light' }
    ]

    const value = {
        list,
        selected,
        onChange: setSelected
    }

    return (
        <Provider value={value}>
            {children}
        </Provider>
    )
}

