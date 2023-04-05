import { CounterWrap } from "Components/CounterWrap"
import { colorSwitchContext } from "Context/colorSwitchContext"
import { Btn, Rows } from "UIKit"
import { useContext } from "react"

export const Context = () => {
    const { color, handleSwitch } = useContext(colorSwitchContext);

    const boxCss = {
        backgroundColor: color,
        width: '100px',
        height: '100px'
    }
    return (
        <Rows>
            <CounterWrap />
            <div>
                <Btn onClick={handleSwitch}>Switch</Btn>
                <div style={boxCss}></div>
            </div>

        </Rows>
    )
}