import { Rows, Line, Btn, Icon } from "UIKit"

export const About = () => {
    const handleClick = () => {
        console.log("CLicked")
    }
    
    return (
        <Rows>
            <h1>About</h1>
            <div>
                <Line>
                    <Icon i="close" />
                    <Icon i="done" />

                    <Btn onClick={handleClick}>Click Me</Btn>
                    <Btn i="close" onClick={handleClick}>Click Me</Btn>
                </Line>
            </div>
        </Rows>
    )
} 