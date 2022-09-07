import { addToMyBook, getAll, removePersonBook} from "./personBookApi";
import {useMutation, useQuery} from 'react-query'
import {queryClient} from '../../hooks/customUseQuery'

const person_books ='person_books'

function useAddPersonBook () {
    return useMutation((params) => addToMyBook(params), {
        onSuccess:() => {
            queryClient.invalidateQueries(person_books)
        }
    })
}

function useShowPersonBook () {
    return useQuery(person_books, () => getAll())
}

function useRemovePersonBook() {
    return useMutation((id) => removePersonBook(id), {
        onSuccess: () =>{ 
            queryClient.invalidateQueries(person_books)
        }
    })
}

export {useAddPersonBook, useShowPersonBook, useRemovePersonBook}