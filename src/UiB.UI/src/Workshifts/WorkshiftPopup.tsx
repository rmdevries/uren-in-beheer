import React from 'react';
import WorkshiftHandler from './WorkshiftHandlers';

function WorkshiftPopup() {
  const {
    inputDate,
    inputStart,
    inputEnd,
    handleDateChange,
    handleStartChange,
    handleEndChange,
    handleWorkshiftSubmit,
  } = WorkshiftHandler();

  return (
    <div className='sm:p-md lg:max-w-screen-lg m-auto py-md'>
      <div className='bg-grey-white rounded-xl shadow-md p-md'>
        <h1 className='font-bold text-2xl my-md'>New workshift</h1>
        <form
          className='flex flex-wrap flex-col'
          onSubmit={handleWorkshiftSubmit}
        >
          <fieldset className='inline-flex flex-col'>
            <label>Date</label>
            <input
              type='date'
              onChange={handleDateChange}
              value={inputDate.toISOString().split('T')[0]}
            />
          </fieldset>
          <fieldset className='inline-flex flex-col my-md'>
            <label>From</label>
            <input
              type='time'
              onChange={handleStartChange}
              value={inputStart}
            />
          </fieldset>
          <fieldset className='inline-flex flex-col'>
            <label>From</label>
            <input type='time' onChange={handleEndChange} value={inputEnd} />
          </fieldset>
          <input
            className='bg-orange rounded-full text-grey-white font-bold p-md mt-md'
            type='submit'
            value='Register'
          />
        </form>
      </div>
    </div>
  );
}

export default WorkshiftPopup;
