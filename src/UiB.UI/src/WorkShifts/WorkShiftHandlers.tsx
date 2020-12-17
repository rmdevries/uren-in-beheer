import { useState } from "react";

function useDate() {
  const [inputDate, setInputDate] = useState(new Date());
  const [inputStart, setInputStart] = useState("08:00");
  const [inputEnd, setInputEnd] = useState("17:00");

  function handleDateChange(event: React.ChangeEvent<HTMLInputElement>) {
    setInputDate(new Date(event.target.value));
  }

  function handleStartChange(event: React.ChangeEvent<HTMLInputElement>) {
    setInputStart(event.target.value);
  }

  function handleEndChange(event: React.ChangeEvent<HTMLInputElement>) {
    setInputEnd(event.target.value);
  }

  function convertToDateTime(date: Date, time: string): Date {
    const [hours, minutes] = time.split(":").map((n) => parseInt(n, 10));
    return new Date(date.setHours(hours, minutes, 0, 0));
  }

  return {
    inputDate,
    inputStart,
    inputEnd,
    handleDateChange,
    handleStartChange,
    handleEndChange,
    convertToDateTime,
  };
}

export default useDate;