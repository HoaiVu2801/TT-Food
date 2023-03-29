import App from "@/App";
import Unit from "../components/index";
import Food from "../FoodByRestaurant/index"
import { createBrowserRouter } from "react-router-dom";


const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    children: [
      {
        path: "/unit",
        element: <Unit/>,
      },
      {
        path: "/food",
        element: <Food/>,
      },
    ],
  },
]);
export default router;