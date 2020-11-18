import React, { useState } from 'react';
import './App.css';

function App() {
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

  function convertToDateTime(date: Date, time: string) : Date {
    const [hours, minutes] = time.split(':').map(n => parseInt(n,10));
    return new Date(date.setHours(hours, minutes, 0, 0));
  }

  return (
    <div>
      <h1>New workshift</h1>
      <form onSubmit={(e) => {
        e.preventDefault();
        
        fetch('http://localhost:5000/api/WorkShift', {
        method: 'POST',
        cache: 'no-cache',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "start": convertToDateTime(inputDate, inputStart),
          "end":  convertToDateTime(inputDate, inputEnd)
        })
      }).then(response => response.json())
      .then(data => console.log(data));
      }}>
        <label>Date</label>
        <input type="date" onChange={handleDateChange} value={inputDate.toISOString().split('T')[0]}></input>
        <label>From</label>
        <input type='time' onChange={handleStartChange} value={inputStart}></input>
        <label>Till</label>
        <input type='time' onChange={handleEndChange} value={inputEnd}></input>
        <input type='submit' value='Register'></input>
      </form>
    </div>
  );
}

export default App;
