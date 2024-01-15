import 'bootstrap/dist/css/bootstrap.min.css';
import { Button } from 'react-bootstrap';
import { NaviBar } from './components/Navibar';
import { Route, Routes } from 'react-router-dom';
import { BrowserRouter as Router } from 'react-router-dom';
import Home from './Home';
import OrdersTable from './OrdersTable.js';
import GetOrder from './Order.js'

function App() {
  return (
    <>
      <Router>
        <NaviBar />
        <Routes>
          <Route exact path="/" element={<Home />} />
          <Route path="/Orders" element={<OrdersTable />} />
          <Route path="/Orders/:id" element={<GetOrder />} />
        </Routes>
      </Router>

    </>
  );
}

export default App;
