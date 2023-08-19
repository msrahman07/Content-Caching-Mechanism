import React from 'react'
import { Container, Nav, Navbar } from 'react-bootstrap'

const NavBar = () => {
  return (
    <Navbar bg="primary" data-bs-theme="dark">
        <Container className='custom-container'>
          <Navbar.Brand href="/">NewsCorp</Navbar.Brand>
        </Container>
      </Navbar>
  )
}

export default NavBar