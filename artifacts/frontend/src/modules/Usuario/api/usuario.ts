/**
 * arquivo de api trata da parte de requisicao e suas configuracoes
 */
import adminApi, { adminApiConfig } from '@/api/admin'
import type {
  Usuario,
  UsuarioCreateReq,
  UsuarioListRes,
  UsuarioCreateRes,
  UsuarioGetRes,
  UsuarioUpdateRes,
  UsuarioDeleteRes,
} from '../types/usuario.d.ts'

const usuarioReqConf = {
  baseURL: adminApiConfig.baseURL + 'usuario',
}

export const listarUsuario = async () => {
  return await adminApi.get<UsuarioListRes>('/', usuarioReqConf)
}

export const criarUsuario = async (usuario: UsuarioCreateReq) => {
  return await adminApi.post<UsuarioCreateRes>('/', usuario, usuarioReqConf)
}

export const obterUsuario = async (id: string) => {
  const { data } = await adminApi.get<UsuarioGetRes>('/' + id, usuarioReqConf)
  return data.value[0]
}

export const atualizarUsuario = async (usuario: Usuario) => {
  return await adminApi.put<UsuarioUpdateRes>('/' + usuario.Id, usuario, usuarioReqConf)
}

export const excluirUsuario = async (id: string) => {
  return await adminApi.delete<UsuarioDeleteRes>('/' + id, usuarioReqConf)
}    