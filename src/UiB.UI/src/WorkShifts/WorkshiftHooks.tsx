import { useEffect, useState } from 'react';
import { IWorkShift } from './IWorkshift';

function useWorkshifts() {
  const [workshifts, setWorkshifts] = useState<IWorkShift[]>();

  useEffect(() => {
    function handleWorkshiftsFetch(data: IWorkShift[]) {
      setWorkshifts(data);
    }

    fetch('/api/WorkShift', {
      method: 'GET',
      cache: 'no-cache',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
    })
      .then((response) => response.json())
      .then((data: IWorkShift[]) => {
        handleWorkshiftsFetch(data);
      })
      .then(() => console.log('Workshifts fetched'))
      .catch((error) => console.log(error));
  }, []);

  return workshifts;
}

export default useWorkshifts;
