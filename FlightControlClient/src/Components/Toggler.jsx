import { useState } from "react"
import { Btn, Rows } from "UIKit"

export const Toggler = ({ children  }) => {
    const [isShow, setIsShow] = useState(true);

    const handleToggle = () => {
        setIsShow(!isShow);
    }
    return (
        <Rows>
            <h2>Toggler</h2>
            <Btn onClick={handleToggle}>Toggle</Btn>
            {isShow && children}
        </Rows>
    )
}