import { useColorSwitch } from "Hooks/useColorSwitch";
import { useCounter } from "Hooks/useCounter";
import { useState } from "react";
import { Btn, Rows } from "UIKit"

/*
    1) create a fully working component
    2) spot the logic and the render
    3) create a "use" function and move the logic there
    4) find what items the render needs from logic
    5) return those items from the "use" function
    6) use the custom hook as if it was a regular hook
    7) export "use" function from another file
*/



export const CounterHook = () => {
    const { count, handleAdd } = useCounter();

    //render
    return (
        <div>
            <h2>Counter Hook, {count}</h2>
            <Btn onClick={handleAdd}>Add</Btn>
        </div>
    )
}

export const AnotherCounter = () => {
    const { count, handleAdd } = useCounter();

    const styleCss = {
        backgroundColor: 'red',
        width: '100px',
        height: '100px'
    }
    return (
        <div>
            <Btn onClick={handleAdd}>Add</Btn>
            {new Array(count).fill(1).map(i => {
                return <div style={styleCss}></div>
            })}
        </div>
    )
}


export const SwitcherHook = () => {
    const {color, handleToggle} = useColorSwitch();

    //render
    const styleCss = {
        backgroundColor: color,
        width: '100px',
        height: '100px'
    }

    const headerStyle = {
        color
    }


    return (
        <Rows>
            <h2 style={headerStyle}>Color Switcher</h2>
            <div style={styleCss}></div>
            <Btn onClick={handleToggle}>Switch</Btn>
        </Rows>
    )
}