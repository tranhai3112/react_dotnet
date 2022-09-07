import './assets/scss/main.scss'
import {useRoutes} from 'react-router-dom'
import {routers} from './routers/routers'

function App() {
  let Element = useRoutes(routers)
  return (
    <>{Element}</>
  ); 
}

export default App;
