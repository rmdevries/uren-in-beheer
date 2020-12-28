import React from 'react';
import { IWorkShift } from './IWorkshift';
import useWorkshifts from './WorkshiftHooks';

function WorkshiftOverview() {
  const workshifts = useWorkshifts();

  return (
    <>
      <table>
        <thead>
          <tr>
            <th>Day</th>
            <th>Start</th>
            <th>End</th>
          </tr>
        </thead>
        <tbody>
          {workshifts?.map((workShift: IWorkShift) => (
            <tr key={workShift.id}>
              <td>{workShift.id}</td>
              <td>{workShift.start}</td>
              <td>{workShift.end}</td>
            </tr>
          ))}
        </tbody>
        <tfoot>
          <tr>
            <td>Total amount of workshifts: {workshifts?.length}</td>
          </tr>
        </tfoot>
      </table>
    </>
  );
}

export default WorkshiftOverview;
