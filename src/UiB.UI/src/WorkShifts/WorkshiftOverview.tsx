import React from 'react';
import { IWorkShift } from './IWorkshift';
import useWorkshifts from './WorkshiftHooks';

function WorkshiftOverview() {
  const workshifts = useWorkshifts();

  return (
    <div className='sm:p-md lg:max-w-screen-lg m-auto'>
      <table className='w-full text-left bg-grey-white rounded-xl shadow-md'>
        <thead>
          <tr>
            <th className='py-md pl-md pr-lg rounded-tl-xl'>Day</th>
            <th className='py-md pr-lg'>Start</th>
            <th className='py-md pr-md rounded-tr-xl'>End</th>
          </tr>
        </thead>
        <tbody>
          {workshifts?.map((workShift: IWorkShift, index: number) => (
            <tr
              key={workShift.id}
              className={`${
                index % 2 === 0 ? 'bg-grey-light' : 'bg-grey-white'
              }`}
            >
              <td className='w-1/3 py-md pl-md pr-lg'>
                {getDate(workShift.start)}
              </td>
              <td className='w-1/3 py-md pr-lg'>{getTime(workShift.start)}</td>
              <td className='w-1/3 py-md pr-md'>{getTime(workShift.end)}</td>
            </tr>
          ))}
        </tbody>
        <tfoot>
          <tr>
            <td className='p-md' colSpan={3}>
              Total workshifts: {workshifts?.length}
            </td>
          </tr>
        </tfoot>
      </table>
    </div>
  );
}

function getDate(date: Date) {
  var dd = new Date(date).getDate();
  var mm = new Date(date).getMonth() + 1;
  var yyyy = new Date(date).getFullYear();

  return `${dd}-${mm}-${yyyy}`;
}

function getTime(date: Date) {
  var hh = new Date(date).getHours();
  var mm = new Date(date).getMinutes();

  var hhString = hh < 10 ? `0${hh}` : hh.toString();
  var mmString = mm < 10 ? `0${mm}` : mm.toString();

  return `${hhString}:${mmString}`;
}

export default WorkshiftOverview;
