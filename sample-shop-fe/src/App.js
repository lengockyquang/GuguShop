import { BrowserRouter } from 'react-router-dom';
import './App.scss';
import AppRoute from './AppRoute';
import AuthProvider from './auth/authProvider';

function App() {
  return (
    <div className="App">
      <AuthProvider>
        <BrowserRouter>
          <AppRoute />
        </BrowserRouter>
      </AuthProvider>
    </div>
  );
}

export default App;
