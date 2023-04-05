import { useState } from "react";

export const useColorSwitch = () => {
    //logic
    const [isRed, setIsRed] = useState(true);

    const handleToggle = () => {
        setIsRed(!isRed);
    }

    const color = isRed ? 'red' : 'blue';

    return {
        color,
        handleToggle
    }
}