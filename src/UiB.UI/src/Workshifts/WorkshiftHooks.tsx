import { useEffect, useState } from 'react';
import { IWorkshift } from './IWorkshift';

function useWorkshifts() {
  const [workshifts, setWorkshifts] = useState<IWorkshift[]>();

  useEffect(() => {
    function handleWorkshiftsFetch(data: IWorkshift[]) {
      setWorkshifts(data);
    }

    fetch('/api/Workshift', {
      method: 'GET',
      cache: 'no-cache',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
    })
      .then((response) => response.json())
      .then((data: IWorkshift[]) => {
        handleWorkshiftsFetch(data);
      })
      .then(() => console.log('Workshifts fetched'))
      .catch((error) => console.log(error));
  }, []);

  return workshifts;
}

export default useWorkshifts;
