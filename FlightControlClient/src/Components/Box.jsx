import './Box.css';

export const Box = ({ title, info, children }) => {
    return (
        <div className='Box'>
            <h1>{title}</h1>
            <h2>{info}</h2>
            <div className='content'>
                {children}
            </div>
        </div>
    )
}