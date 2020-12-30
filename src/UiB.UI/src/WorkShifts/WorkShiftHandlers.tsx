import { useState } from 'react';

function WorkshiftHandler() {
  const [inputDate, setInputDate] = useState(new Date());
  const [inputStart, setInputStart] = useState('08:00');
  const [inputEnd, setInputEnd] = useState('17:00');

  function handleDateChange(event: React.ChangeEvent<HTMLInputElement>) {
    setInputDate(new Date(event.target.value));
  }

  function handleStartChange(event: React.ChangeEvent<HTMLInputElement>) {
    setInputStart(event.target.value);
  }

  function handleEndChange(event: React.ChangeEvent<HTMLInputElement>) {
    setInputEnd(event.target.value);
  }

  function handleWorkShiftSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    fetch('/api/WorkShift', {
      method: 'POST',
      cache: 'no-cache',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        start: convertToDateTime(inputDate, inputStart),
        end: convertToDateTime(inputDate, inputEnd),
      }),
    })
      .then((response) => response.json())
      .then((data) => console.log(data))
      .then(() => window.location.reload());
  }

  function convertToDateTime(date: Date, time: string): Date {
    const [hours, minutes] = time.split(':').map((n) => parseInt(n, 10));
    return new Date(date.setHours(hours, minutes, 0, 0));
  }

  return {
    inputDate,
    inputStart,
    inputEnd,
    handleDateChange,
    handleStartChange,
    handleEndChange,
    handleWorkShiftSubmit,
  };
}

export default WorkshiftHandler;
