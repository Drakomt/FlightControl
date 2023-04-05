import { toggle } from "State/colorSwitch";
import { Btn, Rows } from "UIKit"
import { useDispatch, useSelector } from "react-redux"

export const ColorSwitchRedux = () => {
    const colorSwitch = useSelector(store => store.colorSwitch);
    const dispatch = useDispatch();

    const handleToggle = () => {
        dispatch(toggle());
    }


    const styleCss = {
        backgroundColor: colorSwitch.isRed ? 'red' : 'blue',
        width: '100px',
        height: '100px'
    }
    return (
        <Rows>
            <div style={styleCss}></div>
            <Btn onClick={handleToggle}>Switch</Btn>
        </Rows>
    )
}