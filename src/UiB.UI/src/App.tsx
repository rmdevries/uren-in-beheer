import React from 'react';
import './App.css';
import Header from './Shared/Header';
import WorkshiftPopup from './Workshifts/WorkshiftPopup';
import WorkshiftOverview from './Workshifts/WorkshiftOverview';

function App() {
  return (
    <div>
      <Header />
      <WorkshiftPopup />
      <WorkshiftOverview />
    </div>
  );
}

export default App;
