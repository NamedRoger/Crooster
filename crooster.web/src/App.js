import './App.css';
import { BrowserRouter as Router, Route, Switch} from 'react-router-dom';
import DefaultLayout from './components/DefaultLayout';
import Amigos from './pages/Amigos';
import GalloSemental from './pages/GalloSemental';
import Gallina from './pages/Gallina';
import 'materialize-css/dist/css/materialize.min.css';


function App() {
  return (
    <div className="App">
      <Router>
        <DefaultLayout>
        <Switch>
          <Route exact path="/" component={()=><div>Hola</div>}/>
          <Route exact path="/amigos" component={Amigos}/>
          <Route exact path="/galloSemental" component={GalloSemental}/>
          <Route exact path="/gallina" component={Gallina}/>
        </Switch>
        </DefaultLayout>
      </Router>
    </div>
  );
}

export default App;
