import { useState } from "react";

export const useCounter = () => {
    //logic
   const [count, setCount] = useState(0);

   const handleAdd = () => {
       setCount(count + 1);
   }

   return {
       count,
       handleAdd
   }
}