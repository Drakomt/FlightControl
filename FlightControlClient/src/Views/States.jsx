import { Counter } from "Components/Counter"
import { Toggler } from "Components/Toggler"
import { Rows } from "UIKit"

export const States = () => {


    return (
        <Rows>
            <h1>States</h1>
            <Toggler>
                <Counter />
            </Toggler>
        </Rows>
    )
}