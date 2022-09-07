import {useQuery, QueryClient} from 'react-query'

export const queryClient = new QueryClient({
    defaultOptions:{
        queries: {
            staleTime:Infinity,
            cacheTime:Infinity,
            refetchOnMount:false,
            refetchOnReconnect:false,
            refetchOnWindowFocus:false,
            refetchIntervalInBackground:false
        },
    }
})

export const key = {
    MODAL_ADD_BOOK: "MODAL_ADD_BOOK" //true - false
}

const useRQGlobalState = (key, initialData, options = {}) => [
    useQuery(key, () => initialData, {
        initialData,
        enabled:false,
        ...options
    }).data,
    (value) => queryClient.setQueryData(key, value)
]

export default useRQGlobalState
