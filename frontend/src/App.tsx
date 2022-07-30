import { Suspense } from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.scss';
import AppRoute from './AppRoute';
import AuthProvider from './components/AuthProvider';
import Loading from './components/Loading';

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Suspense fallback={<Loading loading={true} text='Đang tải' />}>
          <AppRoute />
        </Suspense>
      </BrowserRouter>
    </AuthProvider>

  );
}

export default App;
