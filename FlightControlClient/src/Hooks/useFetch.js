import axios from "axios";
import { useEffect, useState } from "react";

export const useFetch = (url) => {
    //logic
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState('');
    const [data, setData] = useState(null);

    useEffect(() => {
        setTimeout(() => {
            fetchNow();
        }, 1000);
    }, [])

    const fetchNow = async () => {
        try {
            const resp = await axios.get(`http://localhost:5132/api` + url);
            setData(resp.data);
        } catch (error) {
            console.log(error);
            setError(error.message);
        } finally {
            setIsLoading(false);
        }
        
    }

    return [
        data,
        isLoading,
        error
    ];
}