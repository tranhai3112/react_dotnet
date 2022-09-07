import BookList from "../components/pages/BookList";
import BookDetails from "../components/pages/BookDetails";
import Layout from "../components/pages/Layout";
import MyBooks from "../components/pages/MyBooks";


export const routers = [
    {
        path: "/",
        element: <Layout/>,
        children: [
            {index: true, element:<BookList/>},
            {path: 'books/:id', element:<BookDetails/>},
            {path: 'my-books', element:<MyBooks/>}
        ]
    }
]