import React from 'react';
import WorkshiftHandler from './WorkShiftHandlers';

function WorkShiftPopup() {
  const {
    inputDate,
    inputStart,
    inputEnd,
    handleDateChange,
    handleStartChange,
    handleEndChange,
    handleWorkShiftSubmit,
  } = WorkshiftHandler();

  return (
    <div className='border border-grey rounded-md'>
      <h1>New workshift</h1>
      <form onSubmit={handleWorkShiftSubmit}>
        <label>Date</label>
        <input
          type='date'
          onChange={handleDateChange}
          value={inputDate.toISOString().split('T')[0]}
        />

        <fieldset className='row'>
          <fieldset className='column'>
            <label>From</label>
            <input
              type='time'
              onChange={handleStartChange}
              value={inputStart}
            />
          </fieldset>
          <fieldset className='column'>
            <label>From</label>
            <input type='time' onChange={handleEndChange} value={inputEnd} />
          </fieldset>
        </fieldset>

        <input className='submitButton' type='submit' value='Register' />
        <input className='cancelButton' type='submit' value='Cancel' />
      </form>
    </div>
  );
}

export default WorkShiftPopup;
