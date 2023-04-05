import { useEffect, useState } from 'react';
import { Between, Icon } from 'UIKit';
import './Dropdown.css';

export const Dropdown = ({ list, selected, onChange }) => {
    const [isOpen, setIsOpen] = useState(false);

    useEffect(() => {
        document.body.addEventListener('click', handleClose);

        return () => {
            document.body.removeEventListener('click', handleClose);
        }
    }, [])

    const handleClose = () => {
        console.log('handleClose')
        setIsOpen(false);
    }

    const handleToggle = (e) => {
        e.stopPropagation();
        console.log('handleToggle')
        setIsOpen(!isOpen);
    }

    const renderTitle = () => {
        if (selected) {
            const item = list.find(i => i.id === selected);
            if (item) {
                return item.name;
            }
        }

        return 'Please Select';
    }

    const getClassName = (id) => {
        if (id === selected) {
            return 'selected'
        }

        return ''
    }

    const handleSelect = (item) => {
        onChange(item.id);
        setIsOpen(false);
    }

    return (
        <div className='Dropdown'>
            <div className='header' onClick={handleToggle}>
                <Between>
                    <h3>{renderTitle()}</h3>
                    <Icon i="keyboard_arrow_down" />
                </Between>
            </div>
            {isOpen && (
                <div className='list'>
                    {list.map(i => (
                        <div
                            key={i.id}
                            className={getClassName(i.id)}
                            onClick={() => handleSelect(i)}
                        >
                            {i.name}
                        </div>
                    ))}
                </div>
            )}
        </div>
    )
}