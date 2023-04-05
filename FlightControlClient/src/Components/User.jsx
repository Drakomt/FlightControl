export const User = (props) => {
    console.log(props);
    return (
        <>
        <h3>{props.name}</h3>
        {props.children}
        </>
    )
}

