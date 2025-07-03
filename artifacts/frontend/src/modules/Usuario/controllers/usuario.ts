/**
 * arquivo controller trata da parte de erros e interface de usuario
 */
import {
  criarUsuario as _criarUsuario,
  listarUsuario as _listarUsuario,
  obterUsuario as _obterUsuario,
  atualizarUsuario as _atualizarUsuario,
  excluirUsuario as _excluirUsuario,
} from '../api/usuario'
import type { Usuario, UsuarioCreateReq } from '../types/usuario'
import { useUiStore } from '@/stores/ui'
import { AxiosError } from 'axios'

export const listarUsuario = async () => {
  try {
    const { data } = await _listarUsuario()
    return data.value
  } catch (error) {
    throw error
  }
}

export const criarUsuario = async (usuario: UsuarioCreateReq) => {
  const ui = useUiStore()

  try {
    const { data } = await _criarUsuario(usuario)

    ui.exibirAlerta({
      text: data.message,
      color: 'success'
    })

    return true

  } catch (error) {
    if (
      error instanceof AxiosError &&
      error.response?.status === 400 &&
      error.response.data.errors
    ) {
      ui.exibirAlertas(
        error.response.data.errors
          .map((err: { mensagem: string }) => ({ text: err.mensagem, color: 'error' }))
      )

      return false

    } else {
      throw error
    }
  }
}

export const obterUsuario = async (id: string) => {
  try {
    const data = await _obterUsuario(id)
    return data
  } catch (error) {
    throw error
  }
}

export const atualizarUsuario = async (usuario: Usuario) => {
  try {
    const { data } = await _atualizarUsuario(usuario)
    return true
  } catch (error) {
    throw error
  }
}

export const excluirUsuario = async (id: string) => {
  try {
    const { data } = await _excluirUsuario(id)
    return true
  } catch (error) {
    throw error
  }
}

export const excluirUsuarios = async (ids: string[]) => {
  try {
    for (const id of ids) {
      const sucesso = await excluirUsuario(id)
    }
    return true
  } catch (error) {
    throw error
  }
}    