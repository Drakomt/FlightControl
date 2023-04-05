import { useFetch } from "Hooks/useFetch";

export const Fetch = ({ url, onRender }) => {
    const [data, isLoading, error] = useFetch(url);

    if(error) {
        return <h4 style={{ color: 'red'}}>{error}</h4>
    }

    if (isLoading) {
        return <h4>loading...</h4>
    }

    if (data) {
        return onRender(data);
    }
}