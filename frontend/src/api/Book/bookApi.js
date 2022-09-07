import axiosClient from '../apiService'

const prefix = 'api/book'

export async function getAllBooks (params){
    try {
        const response  = await axiosClient.get(prefix, params)
        return response
    } catch (error) {
        console.error(error);
        return null;
    }
}

export async function getBook(id) {
    try {
        const url = `${prefix}/${id}`
        const response = await axiosClient.get(url, id)
        return response
    } catch (error) {
        console.error(error)
        return null
    }
}

export async function deleteBook(id) {
    try {
        const url = `${prefix}/${id}`
        const response = await axiosClient.delete(url, id)
        return response
    } catch (error) {
        console.error(error)
        return null
    }
}

export async function addBook(params) {
    try {
        const response = await axiosClient.post(prefix, params)
        return response
    } catch (error) {
        console.error(error)
        return null
    }
}

export async function updateBook(params) {
    try {
        const response =  await axiosClient.put(prefix, params)
        return response
    } catch (error) {
        console.error(error)
        return null
    }
}