import { Suspense } from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.scss';
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
