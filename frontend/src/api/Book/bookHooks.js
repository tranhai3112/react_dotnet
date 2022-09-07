import {getAllBooks, getBook, deleteBook, addBook, updateBook} from './bookApi'
import { useQuery, useMutation } from 'react-query'
import {queryClient} from '../../hooks/customUseQuery'

const books = 'books'

function useBooks(params) {
    return useQuery(books, () => getAllBooks(params))
}

function useBook(id){
    return useQuery(['book',id], () => getBook(id), {enabled:!!id})
}

function useDeleteBook() {
    return useMutation((id) => deleteBook(id),{
        onSuccess:() => {
            queryClient.invalidateQueries(books)
        }
    })
}

function useAddBook() {
    return useMutation(params => addBook(params), {
        onSuccess:() => {
            queryClient.invalidateQueries(books)
        }
    })
}

function useUpdateBook() {
    return useMutation(params => updateBook(params), {
        onSuccess:() => {
            queryClient.invalidateQueries(books)
        }
    })
}

export { useBooks, useBook, useDeleteBook, useAddBook, useUpdateBook}