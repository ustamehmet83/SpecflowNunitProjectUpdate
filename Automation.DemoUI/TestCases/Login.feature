@login @smoke
Feature: Login feature

  Background: kullanıcı giris sayfasında olmalı
    Given kullanıcı netrex giris sayfasında olmalı

  Scenario: admin olarak giris yapalım
    When admin SOEID Yi girer passwordu girer ve login butonuna basar
    Then admin sağ üst köşede "adminsoeid" görmeli

  Scenario: kullanıcı olarak giris yapalım
    When kullanıcı SOEID Yi girer passwordu girer ve login butonuna basar
    Then kullanıcı sağ üst köşede "usersoeid" görmeli

  Scenario Outline: kullanıcı geçersiz bilgilerle giriş yapar
    When kullanıcı geçersiz "<SOEID>" ve geçersiz "<password>" girer
    Then kullanıcı "<alert>" mesajı görmeli
    Examples:
      | SOEID                        | password     | alert                                 |
      | hazal.oncel@hedefbank.com.tr |              | Error: Password Can Not Be Empty      |
      |                              | Password123* | Error: Username Can Not Be Empty      |
      |                              |              | Error: Username Can Not Be Empty      |
      | ıncorrect                    | incorrect    | Error: Incorrect Username or Password |
