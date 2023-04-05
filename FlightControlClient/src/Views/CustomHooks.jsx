import { AnotherCounter, CounterHook, SwitcherHook } from "Components/CounterHook"
import { FetchHook, FetchHookFlights, FetchHookTodos, FetchHookUser } from "Components/FetchHook"
import { Rows } from "UIKit"

export const CustomHooks = () => {
    return (
        <Rows>
             <h1>Custom Hooks</h1>
          {/*    <FetchHookUser />
             <FetchHook />
             <FetchHookTodos /> */}
             <FetchHookFlights/>
        </Rows>
       
    )
}