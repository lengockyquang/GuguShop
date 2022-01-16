import React, { Suspense } from 'react';
import './App.scss';
import { BrowserRouter } from 'react-router-dom';
import AppRoute from './AppRoute';
import Loading from './components/Loading';

function App() {
  return (
    <BrowserRouter>
      <Suspense fallback={<Loading loading={true} text='Đang tải' />}>
        <AppRoute />
      </Suspense>
    </BrowserRouter>
  );
}

export default App;
