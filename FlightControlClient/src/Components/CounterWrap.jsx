import { useState } from "react";
import { Rows } from "UIKit"
import { CounterAdd } from './CounterAdd';
import { CounterDisplay } from "./CounterDisplay";
import { CounterRedux } from "./CounterRedux";
import { ColorSwitchRedux } from "./ColorSwitchRedux";


export const CounterWrap = () => {
    return (
        <Rows>
            {/* <CounterAdd />
            <CounterDisplay /> */}

            <CounterRedux />
            <ColorSwitchRedux />
        </Rows>
    )
}