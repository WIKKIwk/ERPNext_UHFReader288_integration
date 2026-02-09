/****************************************************************************
** Meta object code from reading C++ file 'broadcastudp.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.12.12)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "broadcastudp.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'broadcastudp.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.12.12. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_broadcastudp_t {
    QByteArrayData data[8];
    char stringdata0[85];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_broadcastudp_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_broadcastudp_t qt_meta_stringdata_broadcastudp = {
    {
QT_MOC_LITERAL(0, 0, 12), // "broadcastudp"
QT_MOC_LITERAL(1, 13, 16), // "receivedResponse"
QT_MOC_LITERAL(2, 30, 0), // ""
QT_MOC_LITERAL(3, 31, 12), // "QHostAddress"
QT_MOC_LITERAL(4, 44, 6), // "sender"
QT_MOC_LITERAL(5, 51, 4), // "port"
QT_MOC_LITERAL(6, 56, 4), // "data"
QT_MOC_LITERAL(7, 61, 23) // "handleBroadcastResponse"

    },
    "broadcastudp\0receivedResponse\0\0"
    "QHostAddress\0sender\0port\0data\0"
    "handleBroadcastResponse"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_broadcastudp[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
       2,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       1,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    3,   24,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
       7,    0,   31,    2, 0x08 /* Private */,

 // signals: parameters
    QMetaType::Void, 0x80000000 | 3, QMetaType::UShort, QMetaType::QByteArray,    4,    5,    6,

 // slots: parameters
    QMetaType::Void,

       0        // eod
};

void broadcastudp::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<broadcastudp *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->receivedResponse((*reinterpret_cast< QHostAddress(*)>(_a[1])),(*reinterpret_cast< quint16(*)>(_a[2])),(*reinterpret_cast< QByteArray(*)>(_a[3]))); break;
        case 1: _t->handleBroadcastResponse(); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        {
            using _t = void (broadcastudp::*)(QHostAddress , quint16 , QByteArray );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&broadcastudp::receivedResponse)) {
                *result = 0;
                return;
            }
        }
    }
}

QT_INIT_METAOBJECT const QMetaObject broadcastudp::staticMetaObject = { {
    &QObject::staticMetaObject,
    qt_meta_stringdata_broadcastudp.data,
    qt_meta_data_broadcastudp,
    qt_static_metacall,
    nullptr,
    nullptr
} };


const QMetaObject *broadcastudp::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *broadcastudp::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_broadcastudp.stringdata0))
        return static_cast<void*>(this);
    return QObject::qt_metacast(_clname);
}

int broadcastudp::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QObject::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 2)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 2;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 2)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 2;
    }
    return _id;
}

// SIGNAL 0
void broadcastudp::receivedResponse(QHostAddress _t1, quint16 _t2, QByteArray _t3)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)), const_cast<void*>(reinterpret_cast<const void*>(&_t2)), const_cast<void*>(reinterpret_cast<const void*>(&_t3)) };
    QMetaObject::activate(this, &staticMetaObject, 0, _a);
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
