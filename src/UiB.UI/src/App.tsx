import React from 'react';
import './App.css';
import Header from './Shared/Header';
import WorkShiftPopup from './WorkShifts/WorkShiftPopup';
import WorkshiftOverview from './WorkShifts/WorkshiftOverview';

function App() {
  return (
    <div>
      <Header />
      <WorkShiftPopup />
      <WorkshiftOverview />
    </div>
  );
}

export default App;
