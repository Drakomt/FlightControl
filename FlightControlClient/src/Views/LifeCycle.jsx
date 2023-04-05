import { useCallback, useEffect, useState } from "react"
import { Btn, Rows } from "UIKit"

export const LifeCycle = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [count, setCount] = useState(0);
    
    
    console.log('render');

    useEffect(() => {
       // console.log('mounted');

        document.body.addEventListener('click', handleBodyClick);

        setTimeout(() => {
            setIsLoading(false);
        }, 2000);

        return () => {
            //console.log('unmounted');
            document.body.removeEventListener('click', handleBodyClick);
        }
    }, [])

    useEffect(() => {
        console.log('updated', count);

        return () => {
            console.log('before update', count);
        }
    }, [count])

    const handleBodyClick = () => {
        //console.log('handleBodyClick');
    }

    const handleAdd = useCallback(() => {
        setCount(count + 1)
    }, [count])

    const handleAddVanilla = useCallback(() => {
        document.getElementById('count').innerHTML = `Count, 20`;
    }, [])


    return (
        <Rows>
            {isLoading ? (
                <h1>Loading...</h1>
            ) : (
                <h1>Life Cycle</h1>
            )}
            <h2 id="count">Count, {count}</h2>
            <Btn onClick={handleAdd}>Add</Btn>
            <Btn onClick={handleAddVanilla}>Add Vanilla</Btn>
        </Rows>
    )
}