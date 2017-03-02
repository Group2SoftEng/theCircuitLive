<?php
/*
 * part of work being done to implement PhpUnit on webserver
 **/
class User {
    protected $name;

    public function getName() {
        return $this->name;
    }

    public function setName($name) {
        $this->name = $name;
    }

    public function talk() {
        return "Hello world!";
    }
}
?>