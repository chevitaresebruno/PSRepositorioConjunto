/**
 * arquivo controller trata da parte de erros e interface de usuario
 */
import {
  criarCategoria as _criarCategoria,
  listarCategoria as _listarCategoria,
  obterCategoria as _obterCategoria,
  atualizarCategoria as _atualizarCategoria,
  excluirCategoria as _excluirCategoria,
} from '../api/categoria'
import type { Categoria, CategoriaCreateReq } from '../types/categoria'
import { useUiStore } from '@/stores/ui'
import { AxiosError } from 'axios'

export const listarCategoria = async () => {
  try {
    const { data } = await _listarCategoria()
    return data.value
  } catch (error) {
    throw error
  }
}

export const criarCategoria = async (categoria: CategoriaCreateReq) => {
  const ui = useUiStore()

  try {
    const { data } = await _criarCategoria(categoria)

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

export const obterCategoria = async (id: string) => {
  try {
    const data = await _obterCategoria(id)
    return data
  } catch (error) {
    throw error
  }
}

export const atualizarCategoria = async (categoria: Categoria) => {
  try {
    const { data } = await _atualizarCategoria(categoria)
    return true
  } catch (error) {
    throw error
  }
}

export const excluirCategoria = async (id: string) => {
  try {
    const { data } = await _excluirCategoria(id)
    return true
  } catch (error) {
    throw error
  }
}

export const excluirCategorias = async (ids: string[]) => {
  try {
    for (const id of ids) {
      const sucesso = await excluirCategoria(id)
    }
    return true
  } catch (error) {
    throw error
  }
}    