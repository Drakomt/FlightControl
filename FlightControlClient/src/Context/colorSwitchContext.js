import { createContext, useState } from "react";

export const colorSwitchContext = createContext({});

const Provider = colorSwitchContext.Provider;

export const ColorSwitchProvider = ({ children }) => {
    const [isRed, setIsRed] = useState(true);

    const handleSwitch = () => {
        setIsRed(!isRed);
    }

    const value = {
        isRed,
        handleSwitch,
        color: isRed ? 'var(--primary)' : 'var(--secondary)'
    }

    return (
        <Provider value={value}>
            {children}
        </Provider>
    )
}