/**
 * arquivo de api trata da parte de requisicao e suas configuracoes
 */
import adminApi, { adminApiConfig } from '@/api/admin'
import type {
  Categoria,
  CategoriaCreateReq,
  CategoriaListRes,
  CategoriaCreateRes,
  CategoriaGetRes,
  CategoriaUpdateRes,
  CategoriaDeleteRes,
} from '../types/categoria.d.ts'

const categoriaReqConf = {
  baseURL: adminApiConfig.baseURL + 'categoria',
}

export const listarCategoria = async () => {
  return await adminApi.get<CategoriaListRes>('/', categoriaReqConf)
}

export const criarCategoria = async (categoria: CategoriaCreateReq) => {
  return await adminApi.post<CategoriaCreateRes>('/', categoria, categoriaReqConf)
}

export const obterCategoria = async (id: string) => {
  const { data } = await adminApi.get<CategoriaGetRes>('/' + id, categoriaReqConf)
  return data.value[0]
}

export const atualizarCategoria = async (categoria: Categoria) => {
  return await adminApi.put<CategoriaUpdateRes>('/' + categoria.Id, categoria, categoriaReqConf)
}

export const excluirCategoria = async (id: string) => {
  return await adminApi.delete<CategoriaDeleteRes>('/' + id, categoriaReqConf)
}    